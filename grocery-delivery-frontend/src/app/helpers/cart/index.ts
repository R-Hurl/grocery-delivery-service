export const updateTotalWhenUpdatingCartItem = (
  previousTotal: number,
  productPrice: number,
  previousQuantity: number,
  newQuantity: number
): number => {
  let quantityDifference: number = newQuantity - previousQuantity;
  return previousTotal + productPrice * quantityDifference;
};
