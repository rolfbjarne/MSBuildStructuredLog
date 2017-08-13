﻿using System;
using System.IO;
using Microsoft.Build.Logging.StructuredLogger;

namespace StructuredLogViewer
{
    public class Block
    {
        public string Text { get; set; }
        public double Start { get; set; }
        public double End { get; set; }
        public double Length => End - Start;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public ParentedNode Node { get; set; }
        public int Indent { get; set; }

        public string GetTooltip()
        {
            var text = Node.ToString();

            var project = Node.GetNearestParent<Project>();
            if (project != null)
            {
                text += "\n" + Path.GetFileName(project.ProjectFile);
            }

            if (Node is TimedNode timedNode)
            {
                text += "\n" + Utilities.DisplayDuration(timedNode.Duration);
            }

            return text;
        }
    }
}
