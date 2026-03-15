import { ThemeProvider } from "@react-navigation/native";
import { Stack } from "expo-router";
import { useFonts } from "expo-font";
import { StatusBar } from "expo-status-bar";
import { SafeAreaProvider } from "react-native-safe-area-context";

const RootLayout = () => {
    // Verify that it's loaded, it crashes if it doesn't find the font
    const [loaded] = useFonts({
        SpaceMono: require("../../assets/fonts/SpaceMono-Regular.ttf"),
    });

    // Here goes the Splash Screen
    if (loaded === false) {
        return null;
    }

    return (
        // <ThemeProvider value={lightTheme}>
        <SafeAreaProvider>
            <StatusBar style="auto" />
            <Stack
                screenOptions={{
                    headerTitleStyle: { fontFamily: "SpaceMono" },
                    headerBackTitleStyle: { fontFamily: "SpaceMono" },
                }}
            >
                {/* Primera screen del stack */}
                <Stack.Screen name="index" options={{ title: "Home" }} />
            </Stack>
        </SafeAreaProvider> // </ThemeProvider>
    );
};
export default RootLayout;
