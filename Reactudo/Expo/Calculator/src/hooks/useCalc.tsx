






export const useCalc = () => {
   const [formula, setFormula] = useState("0");
   const [currOperand, setCurrentNumber] = useState("0");
   const [lastCalc, setLastCalc] = useState<LastCalcData>({loop: false, lastResult:0})
   const lastOperator = useRef<Operator>(undefined);

   

   const buildOperand = (newStringValue: string) => {
      if(currOperand.includes(".") && newStringValue === ".") return;
      else if ((currOperand ==="0" || currOperand === "-0") && (newStringValue !== ".")) {
         setFormula(formula.slice(0, -1) + newStringValue);
         setCurrentNumber(newStringValue);
      }
      //else if (lastOperator.current === undefined) { //notOperator selected => first operand
      
   }  
}