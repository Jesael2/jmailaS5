using jmailaS5.Models;
using SQLite;

namespace jmailaS5.Repositories
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;

        public string statusMasagge {  get; set; }

        public PersonRepository(string path)
        {
            dbPath = path;
        }

        private void Init()
        {
            if (conn is not null)
                return;
                conn = new(dbPath);
                conn.CreateTable<Persona>();
            
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Name=name };
                result = conn.Insert(person);
                statusMasagge = string.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {

                statusMasagge = string.Format("ERROR"+ex);
            }
        }

        public List<Persona> GetAllPerson() {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                statusMasagge = string.Format("ERROR" + ex);
            }
            return new List<Persona>();
        
        }
        
    }
}
