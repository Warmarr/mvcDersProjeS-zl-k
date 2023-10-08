using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CatigoryValidatior: AbstractValidator<Category>
    {
        public CatigoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Kısmı Boş Geçilemez!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori Adı En Fazla 20 Karakter Olmalıdır!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır!");

        }
    }
}
