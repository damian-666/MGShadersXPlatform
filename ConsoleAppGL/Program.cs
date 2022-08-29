
using MGCore;

{

    System.Diagnostics.ProcessStartInfo start =
      new System.Diagnostics.ProcessStartInfo();
    start.FileName=@"\ConsoleAppGL.exe";
    start.WindowStyle=System.Diagnostics.ProcessWindowStyle.Hidden; //Hides GUI
    start.CreateNoWindow=true; //Hides console
    var game = new CoreGame();
    CoreGame.IsDirectX = false;
    game.Run();  //this starts the render loop
}
