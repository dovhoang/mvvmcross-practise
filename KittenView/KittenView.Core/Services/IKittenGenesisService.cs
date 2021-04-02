using System;
using System.Collections.Generic;
using System.Text;

namespace KittenView.Core.Services
{
    public interface IKittenGenesisService
    {
        Kitten CreatNewKitten(string extra = "");
    }
}
