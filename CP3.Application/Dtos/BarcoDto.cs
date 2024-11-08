using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public void Validar()
        {
            var resultadoValidacao = new ValidadorBarcoDto().Validar(this);

            if (!resultadoValidacao.EhValido)
            {
                throw new ExcecaoDeValidacao(resultadoValidacao.Erros);
            }
        }

        internal class ValidadorBarcoDto : AbstractValidator<BarcoDto>
        {
            public ValidadorBarcoDto()
            {
                DefinirRegrasNome();
                DefinirRegrasModelo();
                DefinirRegrasAno();
                DefinirRegrasTamanho();
            }

            private void DefinirRegrasNome()
            {
                RuleFor(barco => barco.Nome)
                    .NotEmpty().WithMessage("O campo 'Nome' é obrigatório.")
                    .MaximumLength(100).WithMessage("O 'Nome' não pode exceder 100 caracteres.");
            }

            private void DefinirRegrasModelo()
            {
                RuleFor(barco => barco.Modelo)
                    .NotEmpty().WithMessage("O campo 'Modelo' é obrigatório.")
                    .MaximumLength(50).WithMessage("O 'Modelo' não pode exceder 50 caracteres.");
            }

            private void DefinirRegrasAno()
            {
                RuleFor(barco => barco.Ano)
                    .InclusiveBetween(1900, 2050).WithMessage("O 'Ano' deve estar entre 1900 e 2050.");
            }

            private void DefinirRegrasTamanho()
            {
                RuleFor(barco => barco.Tamanho)
                    .InclusiveBetween(1.0, 500.0).WithMessage("O 'Tamanho' deve estar entre 1.0 e 500.0 metros.");
            }
        }

    }

}
