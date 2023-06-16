import { CluuActionBase, ICluuActionExecutedEventArgs, ICluuActionExecutingEventArgs } from "cluu";
import { DemoWindow } from "./DemoWindow";

/**
 * DemoAction action.
 */
export class DemoAction extends CluuActionBase {
    /**
     * @inheritdoc
     */
    override get name() {
        return "demoClientDevelopment.web.ui.actions.demoAction";
    }

    /**
     * @inheritdoc
     */
    protected override async executeInternalAsync(_: ICluuActionExecutingEventArgs): Promise<ICluuActionExecutedEventArgs> {
        const customWindow = new DemoWindow({});

        const closeResult = await customWindow.showAndWaitForCloseAsync();

        let customData: unknown = null;

        if (closeResult) {
            // Do something
            customData = customWindow.myDemoProperty;
        }

        return { sender: this, result: { customData } };
    }
}
