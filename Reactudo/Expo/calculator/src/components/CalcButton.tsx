import { Text, Pressable } from "react-native";
import { Styles } from "../styles/global-styles";
import { Colors } from "../constants/colors";
import * as Haptics from "expo-haptics";
import { AppText } from "./shared/AppText";

interface CalcButtonProps {
    label: string;
    color?: string;
    blackText?: boolean;
    doubleSize?: boolean;
    onPress: () => void;
}

// rnfe (React Native Function Export)
// Set default values for props (darkGray color, blackText===false (white), doubleSize===false)
export const CalcButton = ({
    label,
    color = Colors.darkGray,
    blackText = false,
    doubleSize = false,
    onPress,
}: CalcButtonProps) => {
    return (
        <Pressable
            style={({ pressed }) => ({
                ...Styles.button,
                backgroundColor: color,
                // Reducir opacidad si está presionado
                opacity: pressed === true ? 0.8 : 1.0,
                // Aumentar width si su propiedad doubleSize es true
                width: doubleSize === true ? 180 : 80,
            })}
            onPress={() => {
                Haptics.selectionAsync();
                onPress();
            }}
        >
            <AppText
                style={{
                    ...Styles.buttonText,
                    color: blackText === true ? "black" : "white",
                }}
            >
                {label}
            </AppText>
        </Pressable>
    );
};
