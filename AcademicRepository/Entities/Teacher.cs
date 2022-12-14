using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _2022_09_23.Attributes;

namespace _2022_09_23.Entities
{
    // Task 26. Használja a modell validációs attribútumokat a modelljeinek property-jein. A property-ket
    // próbálja értelemszerűen ellátni ezekkel az attribútumokkal.
    // Task 27. Készítsen custom modell validációs attribútumot a Neptun kódhoz.A Neptun kód pontosan 6
    // karakterből áll, csak számokat vagy betűket tartalmazhat, és nem kezdődhet számmal.
    public class Teacher : AbstractEntity
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }
        [Required]
        //[MaxLength(6)]
        [NeptunCodeValidationAttribute]
        public string NeptunCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string EmailAddress { get; set; }
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
