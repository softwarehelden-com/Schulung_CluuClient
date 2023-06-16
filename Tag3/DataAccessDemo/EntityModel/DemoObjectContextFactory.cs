using Cluu.Backbone;
using Cluu.DataAccess;

namespace DataAccessDemo.EntityModel;

internal class DemoObjectContextFactory : IDemoObjectContextFactory
{
    private readonly ICluuBackboneProvider cluuBackboneProvider;

    public DemoObjectContextFactory(ICluuBackboneProvider cluuBackboneProvider)
    {
        this.cluuBackboneProvider = cluuBackboneProvider;
    }

    IObjectContext IObjectContextFactory.Create()
    {
        return new DataAccessDemoContext(this.cluuBackboneProvider);
    }
}
