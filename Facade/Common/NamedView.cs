using System.ComponentModel.DataAnnotations;

namespace Abc.Facade.Common
{
    public abstract class NamedView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}