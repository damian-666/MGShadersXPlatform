
using MGCore.DrawTests;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MGCore
{


    /// <summary>
    /// Basic UI and core app level functions for YOUR  game .  for mobile and desktop platforms, built over the general purpose   XNA Game based code
    /// The platfrom dependent parts over this are designed to be as thin as possible, with all shared functionality and game asssets in here
    /// </summary>
    public class GraphicsTestRig : MGGameCore
    {



        public static new GraphicsTestRig Instance;


        public bool IsRunningAllTests = false;

      
        IDrawTest CurrentDrawTest;

        public GraphicsTestRig()
        {
            Instance=this;



        }




        protected override void Initialize()
        {
            base.Initialize();
        }


        public static bool IsDirectX = true;



        /// <summary>
        /// Get via relection all thpes with IDrawTest interface and return them as a list
        /// </summary>
        /// <returns> A list of types</returns>
        List<Type> GetallClassesWithIDrawTestInterace()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var result = types.Where(t => t.GetInterfaces().Contains(typeof(IDrawTest))).ToList();


            return result;
        }
        protected override void LoadContent()
        {
            base.LoadContent();   //mabye dont do this.. conetn get load in each test.. and w em might unlaod it too... or IDispose it...  //TODO

        
            RunAllTests();
            //      CurrentDrawTest=new Bloom();
            //        CurrentDrawTest=new NeonLine();
            //      CurrentDrawTest=new Bloom();
            //    CurrentDrawTest=new Pixelated();
            //     InitTest();

            Window.AllowUserResizing=true;



        }
        /// <summary>
        /// load the contet for each test..   TODo unload
        /// </summary>
        private void InitTest()
        {


            CurrentDrawTest.Initialize(Content, GraphicsDevice, GraphicsDeviceManager);


            //todo move this to eahch test... 

            ////we always have a Device by here
            //GraphicsDevice.PresentationParameters.MultiSampleCount           // set to windows limit, if gpu doesn't support it, monogame will autom. scale it down to the next supported level
            //=GraphicsDeviceManager.PreferMultiSampling ? MsaaSampleLimit : 0;


            Window.Title="MG Cross Platform Shaders "+(IsDirectX ? "DirectX" : "OpenGL"+CurrentDrawTest.GetType().Name);
        }

        protected List<Type> drawTests;
        /// <summary>
        /// activate instance of eachy type and delay between test
        /// </summary>
        public void RunAllTests()
        {

            drawTests=GetallClassesWithIDrawTestInterace();

        }




       
        int CurrentTestIndex { get; set; } = 0;
        /// <summary>
        ///Activate  Instances of types and set CurrentDrawTest to them,  synchronously wiht a dely between them
        /// </summary>
        /// <param name="drawtests"></param>
        public void NextTest(List<Type> drawtests)
        {
            if (CurrentTestIndex++>drawtests.Count-1)
                CurrentTestIndex=0;


            RunTest(CurrentTestIndex, drawtests);
        }



        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
        }



        protected override void BeginRun()
        {

            //either use ui or just run thoug all the tests with one sec deal or somehting .. or if next button presseed.. or scfeen touched .. 

        }

        /// <summary>
        /// TODO run a specific test form adrod or something
        /// </summary>
        /// <param name="i"></param>
        public bool RunTest(int i, List<Type> drawtests)
        {

            bool success = true;
            try
            {

                CurrentDrawTest=Activator.CreateInstance(drawtests[CurrentTestIndex]) as IDrawTest;
                InitTest();

            }



            catch (Exception ex)
            {
                Debug.Write(" test   "+i+" failed "+ex.Message);
                success=false;

            }
            return success;

        }

        /// <summary>
        /// todo use reflection or sometihgin to make a menu for droid to pick a rest..then put the code to just build a menu or set of buttson.. then call this.. 
        /// </summary>
        /// <param name="className"></param>
        public bool RunTest(string className)
        {//todo relfect?

            //so its eash just add a class and it will add ui and test
            return false;

        }

        /// <summary>
        /// total deay between game tests in sec;
        /// </summary>
        public float testdelay = 0.5f;


        protected override void Update(GameTime gt)
        {
            base.Update(gt); //updates the Input keys

            if (IsRunningAllTests)
            {
                if (gt.TotalGameTime.TotalSeconds>testdelay)
                {
                    gt.TotalGameTime=new TimeSpan(0);
                    NextTest(drawTests);
                }
            }else
            {
         
                if ( Keyboard.GetState().IsKeyDown(Keys.Space))
                {

                    NextTest(drawTests);
                }
            }
            //TODO put this on the callback from the GameLoop, it call poll faster on the bk thread that can be faster than 60 hhz , works ok . occasiona touch exceptio colection modified but doesnt seem an issue


            //tOOD maeybe if free 1, 2 three on space to next test..ccyle back

        }



        protected override void Draw(GameTime gameTime)
        {

            CurrentDrawTest?.Draw(gameTime);



        }

    }
}
