import { requireCss } from "cluu";

// Require the css file when this file is loaded.
requireCss("demoClientDevelopment.less");

// Use the import path with the correct case sensitivity.
// The dts-bundle tool does not emit the module declaration correctly if it's wrong.
export * from "../DemoControl";
export * from "../DemoAction";
