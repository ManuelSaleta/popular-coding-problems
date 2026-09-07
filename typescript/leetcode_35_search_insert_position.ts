function searchInsert(nums: number[], target: number): number {
    if (nums.includes(target))
    {
        return nums.indexOf(target);
    }

    nums.forEach((n,index)=> {
        if (n > target) {
            console.log('n ',n);
            return index;
        }
    })
    return -1;
};
