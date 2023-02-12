
using MGCore;
{

    System.Diagnostics.ProcessStartInfo start =
      new System.Diagnostics.ProcessStartInfo();

    //  var path = Assembly.GetEntryAssembly()?.Location;  //might need the exe path on some system.. this is close..

    
    GraphicsTestRig.IsDirectX=false;

    var game = new GraphicsTestRig();

    game.Run();  //this starts the render loop
}
