using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.ViewModels
{
    public class CreateLanguageVM
    {
        // DataNotation   Ui  Validation Ui 

        [DisplayName("Code !")]
        [MinLength(5)]
        public string Code { get; set; }
        [DisplayName("language name")]
        public string Name { get; set; }

    }
}
