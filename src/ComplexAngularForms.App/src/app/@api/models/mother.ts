import { Parent } from "./parent"

export type Mother = Parent & {
    motherId: string,
    maidenName: string,
};
