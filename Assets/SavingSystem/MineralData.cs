using System;

namespace SavingSystems.Data
{
    [Serializable]
    public class MineralData
    {
        public MineralData(MineralScripteblObject MineralScripteblObject)
        {
            this.MineralScripteblObject = MineralScripteblObject;
        }
        public MineralScripteblObject MineralScripteblObject;

    }

}

