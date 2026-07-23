using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Web.ViewModels;

public class CreateTaskViewModel
{
    [Display(Name = "Görev Başlığı")]
    [Required(ErrorMessage = "Başlık zorunludur.")]
    [StringLength(80, ErrorMessage = "Başlık en fazla 80 karakter olabilir.")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Öncelik")]
    [Required(ErrorMessage = "Öncelik seçiniz.")]
    public string Priority { get; set; } = "Normal";

    [Display(Name = "Açıklama")]
    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    public string Description { get; set; } = string.Empty;
}