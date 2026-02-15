


interface AppTextProps extends TextProps {
   variant?: "h1" | "h2";
}

export const AppText: ({ variant = 'h1', ...props}: AppTextProps) => {

   return ( <Text style={ [ {color: "white", fontFamily: "SpaceMono"},
      variant === "h1" ? Styles.mainResult: undefined,
      variant === "h2" ? Styles.subResult: undefined ] }
      numberOfLines={1} adjustsFontSizeToFit={true} {...props} />);
}