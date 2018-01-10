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
            metaRepo.With(typeof(Entity));
            metaRepo.With(typeof(SourcedEntity));
            metaRepo.With(typeof(ContainerEntity));
            metaRepo.With(typeof(NamedEntity));
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
            metaRepo.With(typeof(CSharp.Delegate));
            metaRepo.With(typeof(CSharp.CSharpStruct));
            metaRepo.With(typeof(ParameterizableClass));
            metaRepo.With(typeof(ParameterizedType));
            metaRepo.With(typeof(ParameterType));
            metaRepo.With(typeof(Enum));
            metaRepo.With(typeof(SourceAnchor));
            metaRepo.With(typeof(AbstractFileAnchor));
            metaRepo.With(typeof(FileAnchor));
            metaRepo.With(typeof(Namespace));
            return t.model;
        }
    }
}