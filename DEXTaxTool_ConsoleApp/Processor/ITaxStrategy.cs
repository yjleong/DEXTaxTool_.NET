﻿using BlockExplorerInfo;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public interface ITaxStrategy
    {
        void ProcessTxns(Dictionary<TxnTypeEnum, ITxn[]> txns);
    }
}
