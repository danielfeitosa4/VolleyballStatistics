using System.Net.Mail;
using VolleyballStatistics.Domain.Enums;

namespace VolleyballStatistics.Domain.Seedwork
{
    public abstract class Person : BaseEntity
    {
        // Construtor para garantir a criação válida da entidade
        protected Person() { } // Para frameworks de persistência

        protected Person(string name, string surname, string email, Gender gender, DateTime dateOfBirth, string phone)
        {

            Name = ValidateName(name);
            Surname = ValidateSurname(surname);
            Email = ValidateEmail(email);
            Gender = ValidateGender(gender);
            DateOfBirth = ValidateDataDeNascimento(dateOfBirth);
            Phone = ValidatePhone(phone);

            // Configuração da entidade
            IsEnabled = true;
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
        }

        // Propriedades privadas com encapsulamento
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Phone { get; private set; }

        public bool IsEnabled { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public string? UpdatedBy { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        public void Delete()
        {
            IsEnabled = false;
            DeletedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DeletedAt.Value;
        }

        // Métodos do domínio (comportamentos)
        public void ChangeEmail(string newEmail)
        {
            Email = ValidateEmail(newEmail);
            // Você pode disparar eventos de domínio aqui, como "EmailAlterado"
        }

        public void ChangeName(string newName)
        {
            Name = ValidateName(newName);
        }

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;

            if (DateOfBirth > today.AddYears(-age))
                age--;

            return age;
        }

        // Validações privadas:
        // - Name
        private string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(name));

            if (System.Text.RegularExpressions.Regex.IsMatch(name, @"\d"))
                throw new ArgumentException("O nome não pode conter números.", nameof(name));

            if (name.Length < 3)
                throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.", nameof(name));

            return name;
        }

        // - Surname
        private string ValidateSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(surname));

            if (System.Text.RegularExpressions.Regex.IsMatch(surname, @"\d"))
                throw new ArgumentException("O nome não pode conter números.", nameof(surname));

            if (surname.Length < 3)
                throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.", nameof(surname));

            return surname;
        }

        // - Email
        private string ValidateEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address;
            }
            catch
            {
                throw new ArgumentException("O e-mail informado é inválido.", nameof(email));
            }
        }

        // - Gender
        private Gender ValidateGender(Gender gender)
        {
            if (gender != Gender.Male && gender != Gender.Female)
                throw new ArgumentException("Sexo informado é inválido.", nameof(gender));

            return gender;
        }

        // - DateOfBirth
        private DateTime ValidateDataDeNascimento(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Today)
                throw new ArgumentException("A data de nascimento não pode ser no futuro.", nameof(dateOfBirth));

            if (DateTime.Today.Year - dateOfBirth.Year > 120)
                throw new ArgumentException("A data de nascimento é inválida. Idade maior que 120 anos não permitida.", nameof(dateOfBirth));

            return dateOfBirth;
        }

        // - Phone
        private string ValidatePhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("O número do telefone não pode ser vazio", nameof(phone));

            if (System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\([1-9]{2}\) (?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$"))
                throw new ArgumentException("O número do telefone é inválido.", nameof(phone));

            return phone;
        }
    }
}
