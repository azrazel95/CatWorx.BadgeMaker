using SkiaSharp;

namespace CatWorx.BadgeMaker
{
    //establishing utils class
    class Util
    {
        //getemployees function for manual adding. currently redundant
        public static List<Employee> GetEmployees()
        {
            //establishing our list
            List<Employee> employees = new List<Employee>();
            //it says while true, but its really more of a "until false"
            while (true)
            {
                //rolling through the questions, breaks on leaving empty to move on to next step
                Console.WriteLine("Please enter a name: (leave empty to exit): ");
                //readline, unless empty
                string firstName = Console.ReadLine() ?? "";
                //if empty, break
                if (firstName == "")
                { break; }

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? " ";
                //dont forget your int!!
                Console.Write("Enter Id: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");
                Console.Write("Enter Photo Url: ");
                string photoUrl = Console.ReadLine() ?? "";
                //instantiating new employee as current employee
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                //cheeky add
                employees.Add(currentEmployee);

            }
            //returning the list
            return employees;
        }
        //function that prints to commandline
        public static void PrintEmployees(List<Employee> employees)
        {
            //forloop
            for (int i = 0; i < employees.Count; i++)
            {
                //sure looks like a regular expression
                //its actually a template literal, adds getid first, spaces it out by 10 characters, fullname, spaced by 20 characters,then companyname
                string template = "{0,-10}\t{1,-20}\t{2}";
                //format
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl(), employees[i].GetCompanyName()));
            }
        }
        //creates the csv file
        public static void MakeCSV(List<Employee> employees)
        {
            //if the directory is already there, ignore. otherwise, create
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            //utilizes streamwriter to create a new file. c#'s analog to nodejs's fs
            //using means once its done, kill the process
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                //writes in the file
                file.WriteLine("ID,Name,PhotoUrl");
                //forloop to do it for every employee
                for (int i = 0; i < employees.Count; i++)
                {
                    //template literal
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                    
                }
            }
        }
        //makes the badges
        async public static Task MakeBadges(List<Employee> employees)
        {
            //declaring our positioning
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;

            int COMPANY_NAME_Y = 150;

            int EMPLOYEE_NAME_Y = 600;

            int EMPLOYEE_ID_Y = 730;
            //using httpclient to ping SKIASHARPs api, severs connection when done.
            using (HttpClient client = new HttpClient())
            {
                //forloop rolls through employeelist
                for (int i = 0; i < employees.Count; i++)
                {
                    //gets the photo
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                    //takes the badge to use as background
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));
                    //tells it what the badge is supposed to look like
                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    //a beautiful canvas to live out our artistic fantasies
                    SKCanvas canvas = new SKCanvas(badge);
                    //draws on the canvas
                    canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                    //puts the photo on the badge
                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));
                    //establishes paint object
                    SKPaint paint = new SKPaint();
                    //establishes the paint settings
                    paint.TextSize = 32.0f;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.White;
                    paint.IsStroke = false;
                    paint.TextAlign = SKTextAlign.Center;
                    paint.Typeface = SKTypeface.FromFamilyName("Arial");
                    //draws the company name on
                    canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);
                    //updating some settings
                    paint.Color = SKColors.Black;
                    paint.Typeface = SKTypeface.FromFamilyName("Courier New");
                    //entering the rest of the attributes
                    canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);
                    canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);
                    //final image
                    SKImage finalImage = SKImage.FromBitmap(badge);
                    //encodes the final image back
                    SKData data = finalImage.Encode();
                    //writes it back down to the machine
                    using (var fileStream = File.OpenWrite($"data/employeeBadge{i}.png"))
                    {
                        data.SaveTo(fileStream);
                    }
                }
            }

        }
    }
}
