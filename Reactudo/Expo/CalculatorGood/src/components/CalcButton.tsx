import React from 'react'
import * as Haptics from 'expo-haptics';
import { View, Text, Pressable } from 'react-native'
import { Colors } from '../constants/colors'
import { Styles } from '../styles/global-styles'


interface ButtonProps{
   label: string;
   color?: string;
   blackText?: boolean;
   doubleSize?: boolean;
   onPress:() => void;
}

export const CalcButton = ({label, color = Colors.darkGray, blackText = false, doubleSize = false, onPress}: ButtonProps) => {
  return (
   <Pressable style={ ({pressed}) => ({...Styles.button, backgroundColor: color,
                      opacity: pressed === true ? 0.8 : 1.0, width: doubleSize === true ? 180 : 80})
   }           
   //Haptics is used to give a tactile feedback when the button is pressed. It creates a small vibration that enhances the user experience by providing a physical response to their interaction with the app.
      onPress={() => {Haptics.selectionAsync(); onPress();}}>
   <Text style={ {...Styles.buttonText, color: blackText === true ? "black" : "white"}}>{label}</Text>
   </Pressable>
  )
}
