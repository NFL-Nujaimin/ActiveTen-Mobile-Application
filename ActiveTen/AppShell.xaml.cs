namespace ActiveTen
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("workoutDetails", typeof(WorkoutDetails));
        }
    }
}
