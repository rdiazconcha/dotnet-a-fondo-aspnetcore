using FabuRobotics.Api.Models;

namespace FabuRobotics.Api.Services;

public class RobotService
{
    private static readonly Robot[] Robots =
        [
          new ("FB-01", "Asistente doméstico", "Hogar", 11_999m),
          new ("FB-02", "Asistente de hospitalidad", "Servicio", 12_999m),
          new ("FB-03", "Asistente híbrido", "Hogar y servicio", 10_999m)
        ];


    public IEnumerable<Robot> GetAll()
    {
        return Robots;
    }

    public Robot? GetByCode(string code)
    {
        return Robots.FirstOrDefault(r => 
            string.Equals(r.Code, code, StringComparison.OrdinalIgnoreCase));
    }
}