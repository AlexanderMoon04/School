//rnce snippet
//rnfe snuppet
import { View, Text } from 'react-native'
import { AppText } from '../components/shared/AppText'
// import {useCalc} from '../hooks/useCalc'
import { Styles } from '../styles/global-styles'
import { CalcButton } from '../components/CalcButton'
import { Colors } from '../constants/colors'
import React from 'react'

   
const MyApp = () => {
   return (
      <View style={Styles.calculatorContainer}>
         <View style={{paddingHorizontal: 30, marginBottom: 20}}>
            <AppText variant="h1"> 50 x 50 </AppText>
            <AppText variant="h2"> 2500 </AppText>

            <View style={Styles.row}>
                  <CalcButton label ="C" blackText={true} color={Colors.lightGray} onPress={ () => console.log("C pressed") }/>
                  <CalcButton label ="+/-" blackText={true} color={Colors.lightGray} onPress={ () => console.log("+/- pressed") }/>
                  <CalcButton label ="del" blackText={true} color={Colors.lightGray} onPress={ () => console.log("del pressed") }/>
                  <CalcButton label ="÷" blackText={true} color={Colors.lightGray} onPress={ () => console.log("÷ pressed") }/>
            </View>
         </View>

         <View style={Styles.row}>
            <CalcButton label ="7" onPress={ () => console.log("7 pressed") }/>
            <CalcButton label ="8" onPress={ () => console.log("8 pressed") }/>
            <CalcButton label ="9" onPress={ () => console.log("9 pressed") }/>
            <CalcButton label ="x" color={Colors.orange} onPress={ () => console.log("x pressed") }/>
         </View>

         <View style={Styles.row}>
            <CalcButton label ="4" onPress={ () => console.log("4 pressed") }/>
            <CalcButton label ="5" onPress={ () => console.log("5 pressed") }/>
            <CalcButton label ="6" onPress={ () => console.log("6 pressed") }/>
            <CalcButton label ="-" color={Colors.orange} onPress={ () => console.log("- pressed") }/>
         </View>   

         <View style={Styles.row}>
            <CalcButton label ="1" onPress={ () => console.log("1 pressed") }/>
            <CalcButton label ="2" onPress={ () => console.log("2 pressed") }/>
            <CalcButton label ="3" onPress={ () => console.log("3 pressed") }/>
            <CalcButton label ="+" color={Colors.orange} onPress={ () => console.log("+ pressed") }/>
         </View>

         <View style={Styles.row}>
            <CalcButton label ="0" doubleSize={true} onPress={ () => console.log("0 pressed") }/>
            <CalcButton label ="." onPress={ () => console.log(". pressed") }/>
            <CalcButton label ="=" color={Colors.orange} onPress={ () => console.log("= pressed") }/>
         </View>
      </View>
  )
}
export default MyApp;