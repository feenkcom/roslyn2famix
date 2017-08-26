using Fame;
using Model;

namespace Model
{
    public class FamixModel
    {
        public static Repository Metamodel()
        {
            Tower t = new Fame.Tower();
            MetaRepository metaRepo = t.metamodel;
            metaRepo.With(typeof(Attribute));
            metaRepo.With(typeof(Class));
            metaRepo.With(typeof(Method));
            metaRepo.With(typeof(Type));
            return t.model;
        }
    }
}