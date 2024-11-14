namespace VolleyballStatistics.Domain.Seedwork
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } // Alterado para public por conta do Entity Framework, pois ele realiza o tracking e mapeamento através dela.
    }
}
