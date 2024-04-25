using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airplanes
{
    public class MyObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            LoadDataSource dataSource = subject as LoadDataSource;

            if (dataSource != null)
            {
                // Perform actions based on the notification received from the subject
                Console.WriteLine("Received update from LoadDataSource");

            }
            else
            {
                // Handle unexpected subject type
                Console.WriteLine("Received update from unknown subject type");
            }
        }
    }

}
