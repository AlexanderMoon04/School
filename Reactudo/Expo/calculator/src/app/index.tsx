import { View } from "react-native";
import { CalcButton } from "../components/CalcButton";
import { AppText } from "../components/shared/AppText";
import { Colors } from "../constants/colors";
import { useCalc } from "../hooks/useCalc";
import { Styles } from "../styles/global-styles";

const MyApp = () => {
  const {
    lastCalc,
    formula,
    buildOperand,
    validateOperator,
    calcResult,
    clear,
    deleteLast,
    toggleSign,
  } = useCalc();
  return (
    <View style={(Styles.calculatorContainer, Styles.background)}>
      <View style={{ paddingHorizontal: 30, marginBottom: 20 }}>
        <AppText variant="h1">{formula}</AppText>
        <AppText variant="h2">{lastCalc.lastResult}</AppText>
      </View>

      {/* Top row */}
      <View style={Styles.row}>
        <CalcButton
          label="C"
          blackText={true}
          color={Colors.lightGray}
          // Ponerlo vacio por mientras
          onPress={() => clear()}
        />
        <CalcButton
          label="+/-"
          blackText={true}
          color={Colors.lightGray}
          // Ponerlo vacio por mientras
          onPress={() => toggleSign()}
        />
        <CalcButton
          label="del"
          blackText={true}
          color={Colors.lightGray}
          // Ponerlo vacio por mientras
          onPress={() => deleteLast()}
        />
        <CalcButton
          label="÷"
          color={Colors.orange}
          // Ponerlo vacio por mientras
          onPress={() => validateOperator("/")}
        />
      </View>

      {/* Next row */}
      <View style={Styles.row}>
        <CalcButton
          label="7"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("7")}
        />
        <CalcButton
          label="8"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("8")}
        />
        <CalcButton
          label="9"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("9")}
        />
        <CalcButton
          label="x"
          color={Colors.orange}
          // Ponerlo vacio por mientras
          onPress={() => validateOperator("*")}
        />
      </View>

      {/* Next row */}
      <View style={Styles.row}>
        <CalcButton
          label="4"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("4")}
        />
        <CalcButton
          label="5"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("5")}
        />
        <CalcButton
          label="6"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("6")}
        />
        <CalcButton
          label="-"
          color={Colors.orange}
          // Ponerlo vacio por mientras
          onPress={() => validateOperator("-")}
        />
      </View>

      {/* Next row */}
      <View style={Styles.row}>
        <CalcButton
          label="1"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("1")}
        />
        <CalcButton
          label="2"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("2")}
        />
        <CalcButton
          label="3"
          // Ponerlo vacio por mientras
          onPress={() => buildOperand("3")}
        />
        <CalcButton
          label="+"
          color={Colors.orange}
          // Ponerlo vacio por mientras
          onPress={() => validateOperator("+")}
        />
      </View>

      {/* Next row */}
      <View style={Styles.row}>
        <CalcButton
          label="0"
          doubleSize={true}
          onPress={() => buildOperand("0")}
        />
        <CalcButton label="." onPress={() => buildOperand(".")} />
        <CalcButton
          label="="
          color={Colors.orange}
          onPress={() => calcResult()}
        />
      </View>
    </View>
  );
};
export default MyApp;
