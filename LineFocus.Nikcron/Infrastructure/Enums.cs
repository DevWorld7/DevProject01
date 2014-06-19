using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LineFocus.Nikcron.Infrastructure
{
    public class Enums
    {
        public enum OperationResult { 
            Success, 
            Failure,
            Unknown
        }

        public enum DatabaseOperation { 
            Add,
            Update,
            Delete,
            Select
        }


    }
}