using System.ComponentModel.DataAnnotations;

namespace Flora.Models
{
    public class Contactus
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            [EmailAddress]
            public String Email { get; set; }
            [DataType(DataType.MultilineText)]
            public String Message { get; set; }
        }
    }

