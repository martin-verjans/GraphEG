using GraphEG.Core.DynamicGraph;
using GraphEG.Core.DynamicGraph.Actions.Generator;
using GraphEG.Core.StaticGraph;
using GraphEG.EscapeGame.GameSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public class GameEngine
    {
        private IStaticGraph staticGraph;
        private IEnumerable<IPlayer> Players;
        private IEnumerable<IMetaFunction> metaFunctions;
        private IDynamicGraph dynGraph;
        private readonly GameSessionManager sessionManager;
        private string gameSessionName;
        public event EventHandler<ActionGeneratorBuildingEventArgs> GeneratorBuildingActions;

        public GameEngine(GameSessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public void Start()
        {
            gameSessionName = string.Empty;
            bool newSession = false;
            using (GameLoaderForm form = new GameLoaderForm(sessionManager))
            {
                DialogResult result = form.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                newSession = form.ShouldCreateNewSession;
                gameSessionName = form.SelectedSessionName;
            }
            staticGraph = sessionManager.GetStaticGraph();
            staticGraph.Init();
            if (newSession)
            {
                IEnumerable<Possesses> playerSkills = null;
                using (NewGameForm form = new NewGameForm(staticGraph))
                {
                    DialogResult result = form.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        return;
                    }
                    Players = form.Players;
                    playerSkills = form.PlayerSkills;
                }
                dynGraph = new DynamicGraph(staticGraph, Players, new DynamicEdgeSet(playerSkills));

                ActionGeneratorBuilder generatorBuilder = new ActionGeneratorBuilder();
                generatorBuilder.ActionGeneratorBuilding += GeneratorBuilder_ActionGeneratorBuilding;
                dynGraph.ActionGenerator = generatorBuilder.Build();

                sessionManager.InitSession(gameSessionName);
                sessionManager.StartGame(dynGraph);
            }
            else
            {
                sessionManager.LoadSession(gameSessionName);
                dynGraph = sessionManager.GetDynamicGraph();
            }
            metaFunctions = staticGraph.Nodes.OfType<Meta>().Select(m => m.MetaFunction).OrderByDescending(m => m.ExecutionOrder);
            ShowGameForm();
        }

        private void GeneratorBuilder_ActionGeneratorBuilding(object sender, ActionGeneratorBuildingEventArgs e)
        {
            GeneratorBuildingActions?.Invoke(this, e);
        }

        private void ShowGameForm()
        {
            using (GameEngineForm gameEngineForm = new GameEngineForm())
            {
                gameEngineForm.ActionSelected += GameEngineForm_ActionSelected;
                gameEngineForm.Shown += GameEngineForm_Shown;
                gameEngineForm.ShowDialog();
            }
        }

        private void GameEngineForm_Shown(object sender, EventArgs e)
        {
            GameEngineForm form = (GameEngineForm)sender;
            form.AddToHistory(sessionManager.LoadHistoryForSession(gameSessionName).Select(s => s.Content).Reverse());
            DisplayGraph(form);
        }

        private void DisplayGraph(GameEngineForm form)
        {
            form.DisplayAction(dynGraph.GetPossibleActions());
            form.DisplayGraph(dynGraph);
            if (dynGraph.HavePlayersWon)
            {
                MessageBox.Show("Players have won the game, no action is possible.");
            }
        }

        private void GameEngineForm_ActionSelected(object sender, ActionSelectedEventArgs e)
        {
            GameEngineForm form = (GameEngineForm)sender;
            dynGraph = dynGraph.ExecuteAction(e.SelectedAction);
            List<string> history = new List<string>
            {
                e.SelectedAction.ExecutionResult
            };
            ExecuteMetas(history);
            form.AddToHistory(history);
            sessionManager.SaveDynamicGraph(dynGraph, history);
            DisplayGraph(form);
        }

        private void ExecuteMetas(List<string> history)
        {
            foreach (IMetaFunction function in metaFunctions)
            {
                ExecuteMetaFunction(function, history);
            }
        }

        private void ExecuteMetaFunction(IMetaFunction toExecute, List<string> history)
        {
            if (!toExecute.ShouldTrigger(dynGraph))
                return;
            dynGraph = dynGraph.ExecuteMeta(toExecute);
            if (toExecute.ToString() != $"Meta {toExecute.FunctionName}")
            {
                history.Add(toExecute.ToString());
            }
        }
    }
}
