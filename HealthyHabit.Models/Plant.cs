using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHabit.Models
{
    public class Plant : ModelTemplate
    {
        public string PreviewPath { get; set; }
        public string Stage0Path { get; set; }
        public string Stage1Path { get; set; }
        public string Stage2Path { get; set; }
        public string Stage3Path { get; set; }
        public string Stage4Path { get; set; }
        public string Stage5Path { get; set; }
        public string Stage6Path { get; set; }
        public string Stage7Path { get; set; }
        public string CurrentStage { get; set; }
        public string Name { get; set; }
        public Plant()
        {

        }
        public Plant(string previewpath, string stage0path, string stage1path, string stage2path, string stage3path, string stage4path, string stage5path, string stage6path, string stage7path, string currentStage, string name)
        {
            this.PreviewPath = previewpath;
            this.Stage0Path = stage0path;
            this.Stage1Path = stage1path;
            this.Stage2Path = stage2path;
            this.Stage3Path = stage3path;
            this.Stage4Path = stage4path;
            this.Stage5Path = stage5path;
            this.Stage6Path = stage6path;
            this.Stage7Path = stage7path;
            this.CurrentStage = currentStage;
            this.Name = name;
        }
    }
}
