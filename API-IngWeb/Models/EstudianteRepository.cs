namespace API_IngWeb.Models
{
    public class EstudianteRepository
    {
        private static List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante{Id=1,Name="Julian",Email="julian23@gmail.com",Edad=15},
            new Estudiante{Id=2,Name="Carlos",Email="carlos123@gmail.com",Edad=17}
        };


        public static List<Estudiante> GetEstudiantes()
        {
            return estudiantes;
        }

        public static Estudiante GetEstudianteId(int id)
        {
            return estudiantes.FirstOrDefault(e => e.Id == id);
        }

        public static void AgregarEstudiante(Estudiante estudiante)
        {
            estudiante.Id = estudiantes.Max(e => e.Id) + 1;
            estudiantes.Add(estudiante);
        }

        public static void ActualizarEstudiante(Estudiante estudiante)
        {
            var existeEstudiante = estudiantes.FirstOrDefault(e => e.Id == estudiante.Id);
            if (existeEstudiante != null)
            {
                existeEstudiante.Name = estudiante.Name;
                existeEstudiante.Email = estudiante.Email;
                existeEstudiante.Edad = estudiante.Edad;
            }
        }

        public static void EliminarEstudiante(int Id)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == Id);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
            }
        }
    }
}
