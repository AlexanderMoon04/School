//root components use kebab-case, while other components use camelCase. This is a convention to differentiate between layout components and regular components.
import {useFonts} from "expo-font";
import { Stack } from "expo-router";
import { StatusBar } from "react-native";
import { SafeAreaProvider } from "react-native-safe-area-context";

const RootLayout = () => {
   const [loaded] = useFonts ({SpaceMono: require("../../assets/fonts/SpaceMono-Regular.ttf")});

   if (loaded === false) {return null} //splash screen
   else { }

   return (
      <SafeAreaProvider>
         <StatusBar />
            <Stack screenOptions= { {headerTitleStyle: {fontFamily: "SpaceMono"}, headerBackTitleStyle: {fontFamily: "SpaceMono"}}}>
               <Stack.Screen name="index" options={{title: "Home"}}/>
            </Stack>
      </SafeAreaProvider>
   );
}

export default RootLayout;