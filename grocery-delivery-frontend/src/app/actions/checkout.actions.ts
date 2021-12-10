import { createAction, props } from "@ngrx/store";
import { SubmitOrderModel } from "../models";

export const submitOrder = createAction(
    '[checkout] submitted order',
    props<{ payload: SubmitOrderModel }>()
);