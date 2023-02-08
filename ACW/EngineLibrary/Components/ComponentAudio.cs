using EngineLibrary.Managers;
using OpenTK;
using OpenTK.Audio.OpenAL;

namespace EngineLibrary.Components
{
    public class ComponentAudio : IComponent
    {
        Vector3 sourcePosition;
        int audioSource;
        int audioBuffer;
        bool playing = false;
        public ComponentAudio(string filename, bool loopState)
        {
            audioBuffer = ResourceManager.LoadAudio(filename);
            audioSource = AL.GenSource();
            AL.Source(audioSource, ALSourcei.Buffer, audioBuffer);
            AL.Source(audioSource, ALSourceb.Looping, loopState);
            AL.Source(audioSource, ALSource3f.Position, ref sourcePosition);
            //Play();
        }

        public void Play()
        {
            AL.SourcePlay(audioSource);
            playing = true;
        }
        public void Stop()
        {
            AL.SourceStop(audioSource);
            playing = false;
        }

        public void SetPosition(Vector3 emitterPosition)
        {
            AL.Source(audioSource, ALSource3f.Position, ref emitterPosition);
        }    
        public bool PlayState
        {
            get { return playing; }
        }
        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_AUDIO; }
        }
    }
}
