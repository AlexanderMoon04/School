import { TextProps } from "react-native";
import { Text } from "react-native";
import { Styles } from "../../styles/global-styles";

// Hereda los props de <Text>
interface AppTextProps extends TextProps {
    variant?: "h1" | "h2";
}

// Es basicamente hacer un custom <Text>
//                                         ↓ Todos los demás props (los de <Text>) (Spread)
//                                                        ↓ Interfaz
export const AppText = ({ variant = "h1", ...props }: AppTextProps) => {
    return (
        // El <Text /> y todas sus props
        <Text
            style={[
                { color: "white", fontFamily: "SpaceMono" },
                // If variant == h1, aplicar estilo de mainResult
                variant === "h1" ? Styles.mainResult : undefined,
                // If variant == h2, aplicar estilo de subResult
                // If variant diferente a h2 o h1, aplicar estilo indefinido
                variant === "h2" ? Styles.subResult : undefined,
            ]}
            numberOfLines={1}
            adjustsFontSizeToFit={true}
            // Si puede usar estas props pero son genéricas
            // Las d arriba son 'custom'
            {...props}
        />
    );
};
