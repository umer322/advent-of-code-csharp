// See https://aka.ms/new-console-template for more information

string path = "input.txt";

// Dictionary<string,int> totalBalls = new Dictionary<string,int>{
//     {"red", 0},
//     {"green", 0},
//     {"blue", 0}
// };

int totalPowerSets = 0;

if(File.Exists(path)){
    string[] lines= File.ReadAllLines(path);
    for(int i=0;i<lines.Length;i++){
        Dictionary<string,int> totalBalls = new Dictionary<string,int>{
            {"red", 0},
            {"green", 0},
            {"blue", 0}
        };

        string[] sections = lines[i].Split(":");
        string[] draws = sections[1].Split(";");
        foreach(string draw in draws){
            string[] balls = draw.Split(',');
            foreach(string ball in balls){
               string[] type = ball.Trim().Split(' ');
             
               totalBalls[type[1]] = Math.Max(totalBalls[type[1]], Convert.ToInt32(type[0]));
            }
          
        }
        int totalPower = 1;
        foreach(KeyValuePair<string, int> item in totalBalls){
           totalPower*=item.Value;
        }
        totalPowerSets+=totalPower;
        
    }
    Console.WriteLine(totalPowerSets);
}
