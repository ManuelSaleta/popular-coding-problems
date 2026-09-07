function removeElement(nums: number[], val: number): number {
    let temp = nums.filter(el => el !== val);
    nums.length = 0;
    nums.push(...temp);
    return nums.length
};