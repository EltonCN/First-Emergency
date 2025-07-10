using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

namespace MyUnityScripts.Timeline
{
    public class TextMeshProTextMixerBehaviour : PlayableBehaviour
    {
        string initialText;
        Color initialVertexColor;

        int initialMaxVisibleCharacters;

        float initialFontSize;

        TMP_Text trackBinding;

        
        public PostPlaybackState postPlaybackState;
        
        

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            if (trackBinding == null)
            {
                trackBinding = playerData as TMP_Text;

                initialText = trackBinding.text;
                initialVertexColor = trackBinding.color;
                initialMaxVisibleCharacters = 99999;
                initialFontSize = trackBinding.fontSize;
            }

            if (trackBinding == null)
                return;

            int inputCount = playable.GetInputCount();

            bool hasText = false;
            bool hasColor = false;
            bool hasMaxVisibleCharacters = false;
            bool hasFontSize = false;
            

            Color blendedColor = Color.clear;
            float blendedMaxVisibleCharacters = 0f;
            float blendedFontSize = 0f;

            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);

                Playable input = playable.GetInput(i);

                try
                {
                    ScriptPlayable<TextBehaviour> text = (ScriptPlayable<TextBehaviour>) input;
                    if(inputWeight != 0)
                    {
                        trackBinding.text = text.GetBehaviour().text;
                        hasText = true;
                    }
                }
                catch{}

                try
                {
                    ScriptPlayable<ColorBehaviour> color = (ScriptPlayable<ColorBehaviour>) input;
                    if(inputWeight != 0)
                    {
                        blendedColor += color.GetBehaviour().color * inputWeight;
                        hasColor = true;
                    }
                }
                catch{}

                try
                {
                    ScriptPlayable<VisibleCharactersBehaviour> visibleCharacters = (ScriptPlayable<VisibleCharactersBehaviour>) input;
                    if(inputWeight != 0)
                    {
                        blendedMaxVisibleCharacters += visibleCharacters.GetBehaviour().maxVisibleCharactersPercent * inputWeight;
                        hasMaxVisibleCharacters = true;
                    }
                }
                catch{}

                try
                {
                    ScriptPlayable<FontSizeBehaviour> fontSize = (ScriptPlayable<FontSizeBehaviour>) input;
                    if(inputWeight != 0)
                    {
                        blendedFontSize += fontSize.GetBehaviour().size * inputWeight;
                        hasFontSize = true;
                    }
                }
                catch{}
            }

            if(!hasText)
            {
                trackBinding.text = initialText;
            }

            if(!hasColor)
            {
                trackBinding.color = initialVertexColor;
            }
            else
            {
                trackBinding.color = blendedColor;
            }

            if(!hasMaxVisibleCharacters)
            {
                trackBinding.maxVisibleCharacters = initialMaxVisibleCharacters;   
            }
            else
            {
                blendedMaxVisibleCharacters *= trackBinding.text.Length;
                trackBinding.maxVisibleCharacters = (int) Math.Round(blendedMaxVisibleCharacters);
            }

            if(!hasFontSize)
            {
                trackBinding.fontSize = initialFontSize;
                
            }
            else
            {
                trackBinding.fontSize = blendedFontSize;
            }

        }

        public override void OnPlayableDestroy(Playable playable)
        {
            if (trackBinding == null)
                return;


            switch (postPlaybackState)
            {
                case PostPlaybackState.Revert:
                    trackBinding.text = initialText;
                    trackBinding.color = initialVertexColor;
                    trackBinding.maxVisibleCharacters = initialMaxVisibleCharacters;
                    trackBinding.fontSize = initialFontSize;
                    break;
                case PostPlaybackState.LeaveAsIs:
                    break;
            }

            
        }
    }
}