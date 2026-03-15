import { useRef, useState } from "react";
import { Parser } from "expr-eval";

// This is an 'enum'
export const OPERATOR = {
    add: "+",
    substract: "-",
    multiply: "*",
    divide: "/",
} as const;
export type Operator = (typeof OPERATOR)[keyof typeof OPERATOR];
// This creates a union type: "+" | "-" | "x" | "/"

interface LastCalcData {
    loop?: boolean;
    lastResult: number;
}

export const useCalc = () => {
    const [formula, setFormula] = useState("0");
    const [currOperand, setCurrOperand] = useState("0");
    const [lastCalc, setLastCalc] = useState<LastCalcData>({
        loop: false,
        lastResult: 0,
    });
    const lastOperator = useRef<Operator>(undefined); // Does not call UI render (useState does!)

    // Numbers and "."
    const buildOperand = (newStringValue: string) => {
        if (currOperand.includes(".") && newStringValue === ".") {
            return;
        } else if (
            (currOperand === "0" || currOperand === "-0") &&
            newStringValue !== "."
        ) {
            setFormula(formula.slice(0, -1) + newStringValue);
            setCurrOperand(newStringValue);
        } else if (lastOperator.current === undefined) {
            // If there's no operator
            setFormula(formula + newStringValue);
            setCurrOperand(currOperand + newStringValue);
        } else {
            // If there's an operator
            setFormula(formula + newStringValue);
            setCurrOperand(currOperand + newStringValue);
        }
    };

    const validateOperator = (newStringValue: string) => {
        lastOperator.current = newStringValue as Operator;
        setFormula(formula + newStringValue);
        setCurrOperand("");
    };

    const toggleSign = () => {
      const toggledValue = currOperand.startsWith("-") ? currOperand.slice(1) : "-" + currOperand;

      setFormula(formula => {
         if (lastOperator.current === undefined) {return toggledValue; }
         else {const lastOperandIndex = formula.lastIndexOf(currOperand);
            const formulaPrefix = formula.slice(0, lastOperandIndex);
            return `${formulaPrefix}${toggledValue}`;
         }
      });
      setCurrOperand(toggledValue);
    };
 
    const calcResult = () => {
        try {
            if (currOperand === ".") {
                setFormula(
                    currOperand === "." ? formula.slice(0, -2) : formula,
                );
            } else {
            }
            const result = Parser.evaluate(formula);
            setLastCalc({ lastResult: Number(result.toFixed(8)) });
        } catch (e) {
            return "Syntax Error";
        }
    };
    const clear = () => {
        setFormula("0");
        setCurrOperand("0");
        setLastCalc({ loop: false, lastResult: 0 });
        lastOperator.current = undefined;
    };
    const deleteLast = () => {
        // Quita simbolo de menos si lo tiene
        const auxOperand = currOperand.startsWith("-")
            ? currOperand.slice(1)
            : currOperand;
        if (auxOperand.length > 1) {
            setFormula(formula.slice(0, -1));
            setCurrOperand(currOperand.slice(0, -1));
        } else {
            setFormula(
                (currOperand.startsWith("-")
                    ? formula.slice(0, -2)
                    : formula.slice(0, -1)) + "0",
            );
            setCurrOperand("0");
        }
    };

    return {
        lastCalc,
        formula,
        buildOperand,
        validateOperator,
        calcResult,
        clear,
        deleteLast,
         toggleSign,
    };
};
