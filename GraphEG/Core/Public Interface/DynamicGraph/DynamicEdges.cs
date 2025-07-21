using GraphEG.Core.StaticGraph;

namespace GraphEG.Core.DynamicGraph
{
    public interface ICarriesClue : IDynamicEdge<IPlayer, IClue>    {    }
    public interface ICarriesPuzzle : IDynamicEdge<IPlayer, IPuzzle> { }
    public interface IContainsPlayer : IDynamicEdge<IRoom, IPlayer> { }
    public interface IContainsClue : IDynamicEdge<IRoom, IClue> { }
    public interface IContainsPuzzle : IDynamicEdge<IRoom, IPuzzle> { }
    public interface IContainsRole : IDynamicEdge<IRoom, IRole> { }
    public interface IKnows : IDynamicEdge<IPlayer, IClue> { }
    public interface ILeadsTo : IDynamicEdge<IRoom, IRoom> { }
    public interface IPossesses : IDynamicEdge<IPlayer, ISkill> { }
}
