using UnityEngine;

namespace System
{
    public class GlobalConst 
    {
        [Header("Save")]
        public const string PlayerName = "PlayerName";
        public const string NameKey = "Name";
        public const string SoundKey = "Sound";
        public const string QuestionKey = "Question";
        
        public const string SceneStartGame = "StartGame";
        public const string SceneFirstLocal = "FirstLocal";
        public const string SceneSecondLocal = "SecondLocal";
        public const string SceneThirdLocal = "ThirdLocal";
        public const string DefaultName = "YourName";
        public const string QuestionItems = "QuestionItems";
        
        public enum VariantAnswer
        {
            Unset = 0,
            FirstVar = 1,
            SecondVar = 2,
            ThirdVar = 3,
            FourthVar = 4
        }
    }
}
