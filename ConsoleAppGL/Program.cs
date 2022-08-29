
using MGCore;
{

    System.Diagnostics.ProcessStartInfo start =
      new System.Diagnostics.ProcessStartInfo();

  //  var path = Assembly.GetEntryAssembly()?.Location;  //might need the exe path on some system.. this is close..

    start.FileName=
        //path +
        @"\ConsoleAppGL.exe";
    start.WindowStyle=System.Diagnostics.ProcessWindowStyle.Hidden; //Hides GUI
    start.CreateNoWindow=true; //Hides console
    var game = new CoreGame();
    CoreGame.IsDirectX = false;
    game.Run();  //this starts the render loop
}
