// See https://aka.ms/new-console-template for more information


using System.ComponentModel;




StreamReader streamReader = new StreamReader("input.txt");

int totalCalibrationPoints = 0;
while(!streamReader.EndOfStream){
    int start = default;
    int end = default;

    string? line = streamReader.ReadLine();
    if(line !=null){
        int lastDigitIndex = -1;
        for(int i=0; i< line.Length; i++){
            
            if(Int32.TryParse(line[i].ToString(),out int startValue) && start == default){
                start = startValue;
            }
            else if(start == default && Utilities.HasDigitInString(line.Substring(0,i+1))){
                List<string> numbers = Utilities.GetDigitFromString(line.Substring(0,i+1));
                start = Utilities.Numbers.IndexOf(numbers[0]);
                
            }
            if(Int32.TryParse(line[i].ToString(),out int endValue)){
                end = endValue;
                lastDigitIndex = i;
            }         
            else if(Utilities.HasDigitInString(line.Substring(lastDigitIndex+1,i-lastDigitIndex))){
                List<string> numbers = Utilities.GetDigitFromString(line.Substring(lastDigitIndex+1,i-lastDigitIndex));
                end = Utilities.Numbers.IndexOf(numbers[0]);
                while(numbers.Count()>1){
                    lastDigitIndex+=1;
                    numbers = Utilities.GetDigitFromString(line.Substring(lastDigitIndex+1,i-lastDigitIndex));
                }
                end = Utilities.Numbers.IndexOf(numbers[0]);
            }
            
           
        }
       totalCalibrationPoints+= Convert.ToInt32($"{start}{end}");
    }
}
Console.WriteLine(totalCalibrationPoints);

public static class Utilities{
    public static List<string> Numbers = new List<string>(){"zero","one", "two", "three", "four", "five", "six","seven","eight", "nine"};
    public static bool HasDigitInString(string value){
        return Numbers.Any(value.Contains);
    }
    public static List<string> GetDigitFromString(string value){
        return Numbers.Where(value.Contains).ToList();
    }
}