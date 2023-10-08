using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(X => X.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmı Boş Geçilemez!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar Soyadı En Fazla 50 Karakter Olmalıdır!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar Soyadı En Az 2 Karakter Olmalıdır!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş Geçilemez!");

        }
    }
}
