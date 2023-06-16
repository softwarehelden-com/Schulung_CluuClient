import { assert } from "chai";
import { CluuMonth } from "cluu";
import "mocha";

import { DemoControl } from "../src/DemoControl";

describe("My Control", () => {
    it("Should get the property correctly", () => {
        const myControl = new DemoControl({ myDemoProperty: CluuMonth.January });
        assert(myControl.myDemoProperty == CluuMonth.January);
    });

    it("Should set the property correctly", () => {
        const myControl = new DemoControl({ myDemoProperty: CluuMonth.January });
        myControl.myDemoProperty = CluuMonth.February;
        assert(myControl.myDemoProperty == CluuMonth.February);
    });
});
