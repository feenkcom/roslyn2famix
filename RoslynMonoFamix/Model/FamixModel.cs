using Fame;
using Model;
using FAMIX;

namespace Model
{
    public class FamixModel
    {
        public static Repository Metamodel()
        {
            Tower t = new Fame.Tower();
            MetaRepository metaRepo = t.metamodel;
            metaRepo.With(typeof(Attribute));
            metaRepo.With(typeof(BehaviouralEntity));
            metaRepo.With(typeof(Class));
            metaRepo.With(typeof(Method));
            metaRepo.With(typeof(Type));
            metaRepo.With(typeof(CSharp.CSharpProperty));
            metaRepo.With(typeof(AnnotationType));
            metaRepo.With(typeof(AnnotationTypeAttribute));
            metaRepo.With(typeof(AnnotationInstance));
            metaRepo.With(typeof(AnnotationInstanceAttribute));
            metaRepo.With(typeof(Exception));
            metaRepo.With(typeof(CaughtException));
            metaRepo.With(typeof(ThrownException));
            return t.model;
        }
    }
}