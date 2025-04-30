namespace jmailaS5
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository personRepo{  get; set; }
        public App(Repositories.PersonRepository personRepository)
        {
            InitializeComponent();
            personRepo = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views. vHome());
        }
    }
}