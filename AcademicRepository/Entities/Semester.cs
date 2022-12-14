using System.ComponentModel.DataAnnotations;

namespace _2022_09_23.Entities
{
    // Task 26. Használja a modell validációs attribútumokat a modelljeinek property-jein. A property-ket
    // próbálja értelemszerűen ellátni ezekkel az attribútumokkal.
    public class Semester : AbstractEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string StartDate { get; set; }
        [Required]
        [MaxLength(250)]
        public string EndDate { get; set; }
    }
}
